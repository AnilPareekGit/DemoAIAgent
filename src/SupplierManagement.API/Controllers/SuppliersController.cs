using Microsoft.AspNetCore.Mvc;
using SupplierManagement.API.DTOs;
using SupplierManagement.Domain.Entities;
using SupplierManagement.Domain.Repositories;

namespace SupplierManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierRepository _repository;
    private readonly ILogger<SuppliersController> _logger;

    public SuppliersController(ISupplierRepository repository, ILogger<SuppliersController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    /// Gets all suppliers
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Supplier>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliers()
    {
        _logger.LogInformation("Getting all suppliers");
        var suppliers = await _repository.GetAllAsync();
        return Ok(suppliers);
    }

    /// <summary>
    /// Gets a supplier by ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Supplier), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Supplier>> GetSupplierById(int id)
    {
        _logger.LogInformation("Getting supplier with ID: {Id}", id);
        var supplier = await _repository.GetByIdAsync(id);
        
        if (supplier == null)
        {
            _logger.LogWarning("Supplier with ID {Id} not found", id);
            return NotFound();
        }

        return Ok(supplier);
    }

    /// <summary>
    /// Creates a new supplier
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Supplier), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Supplier>> CreateSupplier([FromBody] CreateSupplierRequest request)
    {
        _logger.LogInformation("Creating new supplier");
        
        var supplier = new Supplier
        {
            Name = request.Name,
            Type = request.Type,
            Email = request.Email,
            Phone = request.Phone,
            Status = request.Status
        };
        
        var createdSupplier = await _repository.CreateAsync(supplier);
        return CreatedAtAction(nameof(GetSupplierById), new { id = createdSupplier.Id }, createdSupplier);
    }
}
