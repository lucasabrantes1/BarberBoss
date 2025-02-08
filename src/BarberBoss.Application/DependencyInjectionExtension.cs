using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Invoicing.Delete;
using BarberBoss.Application.UseCases.Invoicing.GetAll;
using BarberBoss.Application.UseCases.Invoicing.GetById;
using BarberBoss.Application.UseCases.Invoicing.Register;
using BarberBoss.Application.UseCases.Invoicing.Reports.Excel;
using BarberBoss.Application.UseCases.Invoicing.Reports.Pdf;
using BarberBoss.Application.UseCases.Invoicing.Update;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);

    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterInvoicingUseCase, RegisterInvoicingUseCase>();
        services.AddScoped<IGetAllInvoicingUseCase, GetAllExpenseUseCase>();
        services.AddScoped<IGetInvoicingByIdUseCase, GetInvoicingByUseCase>();
        services.AddScoped<IDeleteInvoicingUseCase, DeleteInvoicingUseCase>();
        services.AddScoped<IUpdateInvoicingUseCase, UpdateInvoicingUseCase>();
        services.AddScoped<IGenerateInvoicingReportExcelUseCase, GenerateInvoicingReportExcelUseCase>();
        services.AddScoped<IGenerateInvoicingReportPdfUseCase, GenerateInvoicingReportPdfUseCase>();
    }
}
