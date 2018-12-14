using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

using System.Globalization;
using Newtonsoft.Json.Converters;

namespace Aufgabe_09
{
    public class Answer {
        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("isTrue")]
        public bool isTrue { get; set; }

        public Answer(String text, Boolean isTrue) {
            this.text = text;
            this.isTrue = isTrue;
        }
    }
}