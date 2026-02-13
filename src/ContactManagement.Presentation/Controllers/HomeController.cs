using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.Presentation.Models;
using ContactManagement.Application.DTO.Contacts;
using ContactManagement.Application.Interfaces;

namespace ContactManagement.Presentation.Controllers;

public class HomeController(IContactsService contactsService) : Controller
{
    private readonly IContactsService _contactsService = contactsService;
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var contacts = await _contactsService.GetAllContactsAsync(cancellationToken);
        return View(contacts);
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
    {
        if (file == null || file.Length == 0)
        {
            TempData["Error"] = "Please upload a valid CSV file.";
            return RedirectToAction("Index");
        }
        await _contactsService.ProcessCsvFileAsync(file, cancellationToken);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateContactRequest updateContactRequest, CancellationToken cancellationToken)
    {
        await _contactsService.UpdateContactAsync(updateContactRequest.Id, updateContactRequest, cancellationToken);

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _contactsService.DeleteContactAsync(id, cancellationToken);
        return Ok();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
