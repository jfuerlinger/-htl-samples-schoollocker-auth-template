using System;
using System.Collections.Generic;
using System.Linq;
using SchoolLocker.Core.Entities;
using Utils;

namespace SchoolLocker.ImportConsole
{
    public class ImportController
    {
        const string _filename = "schoollocker.csv";

        /// <summary>
        /// Liefert die Buchungen mit den dazugehörigen Schülern und Spinden
        /// </summary>
        public static IEnumerable<Booking> ReadFromCsv()
        {
            string[][] matrix = MyFile.ReadStringMatrixFromCsv(_filename, true);
            List<Locker> lockers = matrix
                .GroupBy(line => line[2])
                .Select(grp => new Locker { Number = int.Parse(grp.Key) })
                .ToList();

            List<Pupil> pupils = matrix
                .GroupBy(line => line[0] + "_" + line[1])
                .Select(grp => new Pupil
                {
                    Lastname = grp.First()[0],
                    Firstname = grp.First()[1],
                })
                .Select(p =>
                {
                    // TODO: UserName errechnen
                    // p.UserName = ...
                    throw new NotImplementedException();
                    return p;
                })
                .ToList();

            List<Booking> bookings = matrix.Select(line => new Booking
            {
                Pupil = pupils.Single(pupil => line[0] == pupil.Lastname && line[1] == pupil.Firstname),
                Locker = lockers.Single(locker => locker.Number == int.Parse(line[2])),
                From = DateTime.Parse(line[3]),
                To = line[4].Length > 0 ? DateTime.Parse(line[4]) : (DateTime?)null
            }).ToList();
            return bookings;
        }

    }
}
