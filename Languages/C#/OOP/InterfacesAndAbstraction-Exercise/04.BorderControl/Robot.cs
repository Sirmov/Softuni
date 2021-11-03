using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
    }
}
