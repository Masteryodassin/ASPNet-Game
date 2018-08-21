using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game
{
    public enum ParamKey
    {
        TIMESTAMP
    }
    public class Param
    {
        public Param() { }
        public Param(ParamKey key, string value)
        {
            Key = key.ToString();
            Value = value;
        }

        public Param(ParamKey key, long value)
        {
            Key = key.ToString();
            Value = Convert.ToString(value) ;
        }
        [Key]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        public long AsLong()
        {
            try
            {
                return Convert.ToInt64(Value);
            } catch (Exception)
            {
                return default(long);
            }
        }
    }
}