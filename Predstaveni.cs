﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_project
{
    internal class Predstaveni
    {
        private int id_pred;
        private DateTime datPlanovanehoPredstaveni;
        private DateTime datKonanehoPredstaveni;
        private float delkaPredstaveni;
        private Kinosaly kinosal;
        private Filmy film;

        public int Id_pred { get => id_pred; set => id_pred = value; }
        public DateTime DatPlanovanehoPredstaveni 
        { 
            get => datPlanovanehoPredstaveni;
            set
            {
                if (value <= new DateTime(1900, 1, 1))
                {
                    throw new Exception("nevalidni datum narozeni");
                }
                else
                {
                    datPlanovanehoPredstaveni = value;
                }

            }
        }
        public DateTime DatKonanehoPredstaveni 
        { 
            get => datKonanehoPredstaveni;
            set
            {
                if (value <= new DateTime(1900, 1, 1))
                {
                    throw new Exception("nevalidni datum narozeni");
                }
                else
                {
                    datKonanehoPredstaveni = value;
                }

            }
        }
        public float DelkaPredstaveni 
        { 
            get => delkaPredstaveni;
            set 
            {
                if(value < 0)
                {
                    throw new Exception("nevalidni delka predstaveni");

                }
                else
                {
                    delkaPredstaveni = value;
                }
            } 
        }
        internal Kinosaly Kinosal 
        { 
            get => kinosal;
            set
            {
                if (value == null)
                {
                    throw new Exception("nevalidni zanr");
                }
                else
                {
                    kinosal = value;
                }

            }
        }
        internal Filmy Film 
        { 
            get => film;
            set
            {
                if (value == null)
                {
                    throw new Exception("nevalidni zanr");
                }
                else
                {
                    film = value;
                }

            }
        }

        public Predstaveni(DateTime datPlanovanehoPredstaveni, DateTime datKonanehoPredstaveni, float delkaPredstaveni, Kinosaly kinosal, Filmy film)
        {
            DatPlanovanehoPredstaveni = datPlanovanehoPredstaveni;
            DatKonanehoPredstaveni = datKonanehoPredstaveni;
            DelkaPredstaveni = delkaPredstaveni;
            Kinosal = kinosal;
            Film = film;
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
