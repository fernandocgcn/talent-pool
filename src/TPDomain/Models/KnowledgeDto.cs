using TPModel.Models;
using System;
using System.Collections.Generic;

namespace TPDomain.Models
{
    public class KnowledgeDto
    {
        public Knowledge Knowledge { get; set; }
        public short? Rate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is KnowledgeDto dto &&
                   EqualityComparer<Knowledge>.Default.Equals(Knowledge, dto.Knowledge);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Knowledge);
        }
    }
}
