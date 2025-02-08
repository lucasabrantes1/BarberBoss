using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.Expenses;

namespace BarberBoss.Application.UseCases.Invoicing.GetAll;
public class GetAllExpenseUseCase : IGetAllInvoicingUseCase
{
    private readonly IInvoicingReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllExpenseUseCase(IInvoicingReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponsesInvoicingJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponsesInvoicingJson
        {
            Expenses = _mapper.Map<List<ResponseShortInvoicingJson>>(result)
        };
    }
}
