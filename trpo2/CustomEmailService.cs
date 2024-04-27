using System;
using System.Net;
using System.Net.Mail;
using trpo2.Models;

namespace trpo2.Data
{
    public interface IEmailService
    {
        CustomErrorMessage SendMessage(string selectedCountry, string selectedCity, string selectedHotel);
    }

    public class CustomEmailService : IEmailService
    {
        private readonly UserService _userService;

        public CustomEmailService(UserService userService)
        {
            _userService = userService;
        }

        public CustomErrorMessage SendMessage(string selectedCountry, string selectedCity, string selectedHotel)
        {
            const string urlBackground = "https://yourbackgroundimageurl.jpg";
            const string urlLogo = "https://yourlogourl.png";

            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress("studencheskiy.sovet.kit@mail.ru")
                };

                mail.To.Add(_userService.CurrentUser.Email);
                mail.Subject = "Подтверждение бронирования тура";
                mail.Body =
                    $@"<!DOCTYPE html>
                        <html>
                        <head>
                            <title>Подтверждение бронирования тура</title>
                        </head>
                        <body style=""font-family: Montserrat, sans-serif; font-size: 16px; line-height: 1.5; color: #333; background-color: #f5f5f5;"">
                            <div style=""max-width: 600px; margin: 0 auto; padding: 20px; background-color: #fff; border-radius: 5px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); background-image: url({urlBackground}); background-size: cover;"">
                                <h1 style=""font-size: 24px; margin-top: 0; margin-bottom: 20px; text-align: center; color: black;"">Подтверждение бронирования тура</h1>
                                <div style=""background-color: #fff; border: 1px solid #ccc; border-radius: 5px; padding: 20px; margin-bottom: 20px;"">
                                    <div style=""display: flex; align-items: center; justify-content: space-between; margin-bottom: 20px;"">
                                        <div style=""width: 100px; height: 100px; background-color: #ccc; border-radius: 50%; margin-right: 20px; background-image: url({urlLogo}); background-position: center; background-size: contain; background-size: cover;""></div>
                                        <h1 style=""font-family: Montserrat Black; padding-top: 10px; font-size: 40px; color: #333;"">Подтверждение бронирования тура</h1>
                                    </div>
                                    <div style=""display: flex; flex-direction: column; margin-bottom: 20px;"">
                                        <div style=""display: flex; align-items: center; margin-bottom: 10px;"">
                                            <span style=""font-weight: bold; margin-right: 10px; color: #333;"">Страна:</span>
                                            <span style=""margin: 0; color: #666;"">{selectedCountry}</span>
                                        </div>
                                        <div style=""display: flex; align-items: center; margin-bottom: 10px;"">
                                            <span style=""font-weight: bold; margin-right: 10px; color: #333;"">Город:</span>
                                            <span style=""margin: 0; color: #666;"">{selectedCity}</span>
                                        </div>
                                        <div style=""display: flex; align-items: center; margin-bottom: 10px;"">
                                            <span style=""font-weight: bold; margin-right: 10px; color: #333;"">Отель:</span>
                                            <span style=""margin: 0; color: #666;"">{selectedHotel}</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </body>
                        </html>";

                mail.IsBodyHtml = true;

                var smtp = new SmtpClient("smtp.mail.ru", 587)
                {
                    Credentials = new NetworkCredential("studencheskiy.sovet.kit@mail.ru", "jUprRdgq75S5dYasZik4"),
                    EnableSsl = true
                };

                smtp.Send(mail);
                return new CustomErrorMessage
                {
                    ErrorMessage = $"Письмо успешно отправлено.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new CustomErrorMessage
                {
                    ErrorMessage = ex.Message,
                    Success = false
                };
            }
        }
    }
}