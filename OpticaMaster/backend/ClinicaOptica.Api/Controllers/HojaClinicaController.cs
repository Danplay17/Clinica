using Microsoft.AspNetCore.Mvc;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar las secciones de la hoja clínica.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HojaClinicaController : ControllerBase
    {
        private readonly IAntecedentesRepository _antecedentesRepository;
        private readonly IConsultaRepository _consultaRepository;

        public HojaClinicaController(
            IAntecedentesRepository antecedentesRepository,
            IConsultaRepository consultaRepository)
        {
            _antecedentesRepository = antecedentesRepository;
            _consultaRepository = consultaRepository;
        }

        /// <summary>
        /// Obtiene los antecedentes de una consulta específica.
        /// </summary>
        [HttpGet("antecedentes/{consultaId}")]
        public async Task<ActionResult<Antecedentes>> GetAntecedentes(int consultaId)
        {
            var antecedentes = await _antecedentesRepository.GetByConsultaIdAsync(consultaId);
            
            if (antecedentes == null)
                return NotFound("No se encontraron antecedentes para esta consulta");

            return Ok(antecedentes);
        }

        /// <summary>
        /// Crea o actualiza los antecedentes de una consulta.
        /// </summary>
        [HttpPost("antecedentes")]
        public async Task<ActionResult<Antecedentes>> SaveAntecedentes([FromBody] Antecedentes antecedentes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verificar que la consulta existe
            var consulta = await _consultaRepository.GetByIdAsync(antecedentes.ConsultaId);
            if (consulta == null)
                return BadRequest("La consulta especificada no existe");

            Antecedentes result;
            
            // Si ya existen antecedentes, actualizar; si no, crear
            var existing = await _antecedentesRepository.GetByConsultaIdAsync(antecedentes.ConsultaId);
            if (existing != null)
            {
                existing.HeredoFamiliares = antecedentes.HeredoFamiliares;
                existing.NoPatologicos = antecedentes.NoPatologicos;
                existing.Patologicos = antecedentes.Patologicos;
                existing.PadecimientoActual = antecedentes.PadecimientoActual;
                existing.Prediagnostico = antecedentes.Prediagnostico;
                
                result = await _antecedentesRepository.UpdateAsync(existing);
            }
            else
            {
                result = await _antecedentesRepository.CreateAsync(antecedentes);
            }

            return CreatedAtAction(nameof(GetAntecedentes), new { consultaId = result.ConsultaId }, result);
        }

        /// <summary>
        /// Obtiene una consulta completa con todas sus secciones clínicas.
        /// </summary>
        [HttpGet("consulta/{consultaId}")]
        public async Task<ActionResult<object>> GetConsultaCompleta(int consultaId)
        {
            var consulta = await _consultaRepository.GetByIdAsync(consultaId);
            if (consulta == null)
                return NotFound("Consulta no encontrada");

            var antecedentes = await _antecedentesRepository.GetByConsultaIdAsync(consultaId);

            var consultaCompleta = new
            {
                Consulta = consulta,
                Antecedentes = antecedentes,
                // Aquí se agregarían las otras secciones cuando se implementen
                // AgudezaVisual = agudezaVisual,
                // Lensometria = lensometria,
                // Refraccion = refraccion,
                // RecetaFinal = recetaFinal
            };

            return Ok(consultaCompleta);
        }
    }
} 