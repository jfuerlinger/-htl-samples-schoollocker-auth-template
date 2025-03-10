﻿using SchoolLocker.Core.Validations;
using SmartSchool.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolLocker.Core.Entities
{
    public class Booking : EntityObject
    {

        public int LockerId { get; set; }

        [ForeignKey(nameof(LockerId))]
        public Locker Locker { get; set; }
        public int PupilId { get; set; }

        [ForeignKey(nameof(PupilId))]
        public Pupil Pupil { get; set; }

        [FromValidation]
        public DateTime From { get; set; }

        [ToValidation]
        public DateTime? To { get; set; }

    }
}
