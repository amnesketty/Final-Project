using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using lounga.Data;
using lounga.Dto.BookingFlight;
using lounga.Dto.File;
using lounga.Model;
using lounga.Services.FileService;
using Microsoft.EntityFrameworkCore;

namespace lounga.Services.BookingFlightService
{
    public class BookingFlightService : IBookingFlightService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMailService _mailService;
        public BookingFlightService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor, IMailService mailService)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _mailService = mailService;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<GetBookingFlightDto>> AddBookingFlight(AddBookingFlightDto newBookingFlight)
        {
            ServiceResponse<GetBookingFlightDto> response = new ServiceResponse<GetBookingFlightDto>();
            try
            {
                BookingFlight bookingFlight = _mapper.Map<BookingFlight>(newBookingFlight);
                bookingFlight.BookingDate = newBookingFlight.BookingDate;
                var flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == newBookingFlight.FlightId);
                bookingFlight.Flight = flight;

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
                bookingFlight.User = user;
                var email = user?.Email;

                var random = new Random().Next(100000,999999).ToString();
                string fl = "FL-";
                var bookingNo = fl+random;
                bookingFlight.BookingFlightNo = bookingNo;

                _context.BookingFlights.Add(bookingFlight);

                var mailRequest = new MailRequest();
                mailRequest.Body = "Your Flight Booking Number is " + bookingNo;
                mailRequest.Subject = "Lounga Flight Booking";
                mailRequest.ToEmail = email;
                await _context.SaveChangesAsync();
                await _mailService.SendEmailAsync(mailRequest);

                response.Data = _mapper.Map<GetBookingFlightDto>(bookingFlight);
                response.Message = "Data Booking succesfully added";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}