﻿using DAL_ADO.Models;
using GestionEvenementsAPI.Models;
using GestionEvenementsAPI.Models.DTO;
using GestionEvenementsAPI.Models.Form;

namespace GestionEvenementsAPI.Tools
{
    public static class Mapper
   {
      public static Event ToDal(this EventCreate eventCreate)
      {
         return new Event
         {
            Name = eventCreate.Name,
            StartDate = eventCreate.StartDate,
            EndDate = eventCreate.EndDate,
            Location = eventCreate.Location,
            Adress = eventCreate.Adress
         };
      }
      public static UserView ToUserView(this User user)
      {
         return new UserView { Id = user.Id, NickName = user.NickName };
      }

      public static EventTypeDay ToCreate(this EventTypeDayCreate e)
      {
         return new EventTypeDay
         {
            Date = e.Date,
            EventId = e.EventId,
            Type = new EventType { Id = e.TypeId }
         };
      }

      public static EventDTO ToDTO(this Event ev) 
      {
         return new EventDTO
         {
            Id = ev.Id,
            Name = ev.Name,
            StartDate = ev.StartDate,
            EndDate = ev.EndDate,
            Location = ev.Location,
            Adress = ev.Adress,
            TypeByDays = ev.TypeByDays,
            Status = ev.Status.Name

         };
      }

   }
}
