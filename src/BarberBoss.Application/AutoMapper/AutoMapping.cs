using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;

namespace BarberBoss.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping() 
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestInvoicingJson, Invoicing>();
    }

    private void EntityToResponse()
    {
        CreateMap<Invoicing, ResponseRegisteredInvoicingJson>();
        CreateMap<Invoicing, ResponseShortInvoicingJson>();
        CreateMap<Invoicing, ResponseExpenseJson>();
    }
}
