using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace Core.Entities
{
    public class Artist : BaseEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTimeOffset CreatedDate { get; private set; } = DateTimeOffset.Now;
        public DateTimeOffset Update { get; private set; } = DateTimeOffset.Now;
        [Required]
        public string Name { get; set; }
        [Required]
        public int Streams { get; set; }
        [Required]
        public double Rate { get; set; }
        public Artist(string name,int streams,double rate)
        {
            Guard.Against.Null(name, nameof(name));
            Guard.Against.Null(streams, nameof(streams));
            Guard.Against.Null(rate, nameof(rate));
            Name = name;
            Streams = streams;
            Rate = rate;
        }
        public void SetValue(string name, int streams, double rate)
        {
            Guard.Against.Null(name, nameof(name));
            Guard.Against.Null(streams, nameof(streams));
            Guard.Against.Null(rate, nameof(rate));
            Name = name;
            Streams = streams;
            Rate = rate;
        }
        public Artist() { }


    }
}
