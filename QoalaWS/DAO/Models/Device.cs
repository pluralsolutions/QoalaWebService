﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using QoalaWS.Exceptions;
using System.Data.Entity;

namespace QoalaWS.DAO
{
    public partial class Device
    {
        public static Device findById(QoalaEntities context, Decimal id_device)
        {
            return context.DEVICES.FirstOrDefault(u => u.ID_DEVICE == id_device && !u.DELETED_AT.HasValue);
        }

        public decimal? Add(QoalaEntities context)
        {
            var outParameter = new ObjectParameter("OUT_ID_DEVICE", typeof(decimal));
            context.SP_INSERT_DEVICE(ALIAS, COLOR, FREQUENCY_UPDATE, ID_USER, outParameter);
            if (outParameter.Value == DBNull.Value)
                throw new CreateRecordException();

            ID_DEVICE = (Decimal)outParameter.Value;
            context.Entry(this).State = EntityState.Unchanged;
            return ID_DEVICE;
        }

        public decimal? Update(QoalaEntities context)
        {
            var outParameter = new ObjectParameter("ROWCOUNT", typeof(decimal));
            context.SP_UPDATE_DEVICE(
                ID_DEVICE, 
                ALIAS, 
                COLOR, 
                FREQUENCY_UPDATE, 
                ID_USER, 
                outParameter
            );
            return 1;
        }

        public decimal? Delete(QoalaEntities context)
        {
            var outParameter = new ObjectParameter("ROWCOUNT", typeof(decimal));
            context.SP_DELETE_DEVICE(ID_DEVICE, outParameter);
            context.Entry(this).State = EntityState.Unchanged;
            return 1;
        }

        public decimal? TurnAlarm(QoalaEntities context)
        {
            var outParameter = new ObjectParameter("ROWCOUNT", typeof(decimal));
            context.SP_TURN_ALARM(ID_DEVICE, ((bool)ALARM ? 1 : 0), outParameter);
            return 1;
        }

        public decimal? UpdateLastLocation(QoalaEntities context)
        {
            var outParameter = new ObjectParameter("ROWCOUNT", typeof(decimal));
            context.SP_UPDATE_LAST_LOCATION(ID_DEVICE, LAST_LONGITUDE, LAST_LATITUDE, outParameter);
            return 1;
        }
    }
}