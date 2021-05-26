using System;
using System.IO;
using System.Text;
using System.Windows;
using AveCaesarApp.Models;
using AveCaesarApp.Repository;
using AveCaesarApp.Services;
using AveCaesarApp.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;

namespace AveCaesarApp.Commands
{
    class PrintBillCommand : Command
    {
        private readonly ConcreteOrderViewModel _orderViewModel;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public PrintBillCommand(ConcreteOrderViewModel orderViewModel, UnitOfWorkFactory unitOfWorkFactory)
        {
            _orderViewModel = orderViewModel;
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public override bool CanExecute(object parameter)
        {
            if(_orderViewModel.StatusViewModel.SelectedItem != OrderStatus.Ready )
            {
                MessageBox.Show("Чек можно сформировать только если заказ готов", "Ошибка");
                return false;
            }
            return AccessService.CanProfileAccessOrder(_orderViewModel.authenticationStore.CurrentProfile)
                                                                && MessageBox.Show("Хотите сформировать чек?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
       
        public override async void Execute(object parameter)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _orderViewModel.CurrentOrder.Status = FullOrderStatus.Finished;
                var currentOrder = unitOfWork.OrderRepository.Get(_orderViewModel.CurrentOrder.Id);
                currentOrder.Status = FullOrderStatus.Finished;
                await unitOfWork.SaveAsync();
            }

            string billsPath = AppDomain.CurrentDomain.BaseDirectory + "\\Bills";
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            string fileName = string.Concat("N", _orderViewModel.CurrentOrder.Id, "_",
                _orderViewModel.CurrentOrder.AcceptedTime.ToShortDateString() + ".pdf");
            try
            {
                if (!Directory.Exists(billsPath))
                    Directory.CreateDirectory(billsPath);

                string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                PdfWriter.GetInstance(doc,
                    new FileStream(billsPath + $"\\{fileName}", FileMode.Create));
                BaseFont bf = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font = new Font(bf, 20, Font.NORMAL);
                doc.Open();
                doc.Add(new Paragraph("Ресторан здорового питания Ave Caesar", font) {Alignment = 1});
                doc.Add(new Paragraph($"Заказ номер: {_orderViewModel.CurrentOrder.Id}", font) { Alignment = 0 });
                doc.Add(new Paragraph($"Дата оформления заказа: {_orderViewModel.CurrentOrder.AcceptedTime}", font) { Alignment = 0 });
                doc.Add(new Paragraph($"Имя официанта: {_orderViewModel.CurrentOrder.WaiterName}", font){Alignment = 0});
                doc.Add(new Paragraph($"Имя повара: {_orderViewModel.CurrentOrder.ChefName}", font) { Alignment = 0 });
                doc.Add(new Paragraph($"Номер столика: {_orderViewModel.CurrentOrder.TableNumber}", font) { Alignment = 0 });
                doc.Add(new Paragraph("ЗАКАЗ", font) { Alignment = 1 });
                int count = 1;
                foreach (var dish in _orderViewModel.CurrentOrder.DishesOrders)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(count++ + ")");
                    builder.Append(" Блюдо: " + dish.Dish.Name + "\n");
                    builder.Append("    Количество: " + dish.DishAmount + "\n");
                    builder.Append("    Цена: " + dish.Dish.Price*dish.DishAmount + " руб. " + $"({dish.Dish.Price} руб. / порция)");
                    doc.Add(new Paragraph(builder.ToString(), font));
                }
                doc.Add(new Paragraph(new string('-', Convert.ToInt32(doc.PageSize.Width/5))));
                doc.Add(new Paragraph($"Итого: {_orderViewModel.CurrentOrder.TotalPrice} руб.", font) { Alignment = 0 });
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                doc.Close();
            }

            _orderViewModel.NavigateToOrdersCommand.Execute(null);
        }
    }
}
