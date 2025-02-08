using BarberBoss.Application.UseCases.Invoicing.Delete;
using BarberBoss.Application.UseCases.Invoicing.GetAll;
using BarberBoss.Application.UseCases.Invoicing.GetById;
using BarberBoss.Application.UseCases.Invoicing.Register;
using BarberBoss.Application.UseCases.Invoicing.Update;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicingController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredInvoicingJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterInvoicing(
        [FromServices] IRegisterInvoicingUseCase useCase,
        [FromBody] RequestInvoicingJson request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }


    [HttpGet]
    [ProducesResponseType(typeof(ResponsesInvoicingJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllIInvoicings([FromServices] IGetAllInvoicingUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Expenses.Count != 0)
            return Ok(response);

        return NoContent();
    }


    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseExpenseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetInvoicingByIdUseCase useCase,
        [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }


    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseExpenseJson), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteInvoicingUseCase useCase,
        [FromRoute] long id)
    {
     await useCase.Execute(id);

     return NoContent();
    }


    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseExpenseJson), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
    [FromServices] IUpdateInvoicingUseCase useCase,
    [FromRoute] long id,
    [FromBody] RequestInvoicingJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}
