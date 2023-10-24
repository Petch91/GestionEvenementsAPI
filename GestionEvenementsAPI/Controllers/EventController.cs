using DAL_ADO.Interfaces;
using DAL_ADO.Models;
using GestionEvenementsAPI.Models.Form;
using GestionEvenementsAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace GestionEvenementsAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class EventController : ControllerBase
   {
      private readonly IEventService _eventService;
      private readonly IEventTypeDayService _eventTypeDayService;
      private readonly IEventTypeService _eventTypeService;

      public EventController(IEventService eventService, IEventTypeDayService eventTypeDayService, IEventTypeService eventTypeService)
      {
         _eventService = eventService;
         _eventTypeDayService = eventTypeDayService;
         _eventTypeService = eventTypeService;
      }
      [HttpGet]
      public IActionResult Get()
      {
         IEnumerable<Event> events = _eventService.ReadAll();
         foreach (Event e in events) 
         {
            IEnumerable<EventTypeDay> etd = _eventTypeDayService.ReadAll("EventTypeDayView").Where(et => et.EventId == e.Id);
            e.AddTypeByDay(etd);
         }
         
         return Ok(events);
      }
      //[Authorize("AdminPolicy")]
      [HttpPost]
      public IActionResult Post([FromBody] EventCreate @event)
      {
         if (!ModelState.IsValid) { return BadRequest(); }

         try
         {
            _eventService.Create(@event.ToDal());
            return Ok();
         }
         catch (Exception ex)
         {
            return BadRequest(ex.Message);
         }
      }

      [HttpPost("AddTypeByDay")]
      public IActionResult AddType([FromBody] EventTypeDayCreate eventTypeDays)
      {

            _eventTypeDayService.Create(eventTypeDays.ToCreate());

         return Ok();
      }

      [HttpGet("GetTypes")]
      public IActionResult GetTypes()
      {
         return Ok(_eventTypeService.ReadAll());
      }
   }
}
