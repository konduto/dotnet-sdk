using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoHotelRoom : KondutoModel
    {
        [JsonProperty("number")]
        public String Number { get; set; }

        [JsonProperty("code")]
        public String Code { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:mm:ssZ
        /// </summary>
        [JsonProperty("check_in_date", Required = Required.Always)]
        public String CheckInDate { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:mm:ssZ
        /// </summary>
        [JsonProperty("check_out_date")]
        public String CheckOutDate { get; set; }

        [JsonProperty("number_of_guests")]
        public int? NumberOfGuests { get; set; }

        [JsonProperty("board_basis")]
        public String BoardBasis { get; set; }

        [JsonProperty("guests", Required = Required.Always)]
        public List<KondutoHotelGuest> Guests { get; set; }

        public KondutoHotelRoom() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoHotelRoom)) return false;

            KondutoHotelRoom that = o as KondutoHotelRoom;

            if (!object.Equals(Number, that.Number)) return false;
            if (!object.Equals(Code, that.Code)) return false;
            if (!object.Equals(Type, that.Type)) return false;
            if (!object.Equals(CheckInDate, that.CheckInDate)) return false;
            if (!object.Equals(CheckOutDate, that.CheckOutDate)) return false;
            if (!object.Equals(NumberOfGuests, that.NumberOfGuests)) return false;
            if (!object.Equals(BoardBasis, that.BoardBasis)) return false;

            if (Guests != null && that.Guests != null)
            {
                if (!Guests.SequenceEqual(that.Guests)) return false;
            }
            else if (Guests != that.Guests) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
