using System;
using System.Collections.Generic;
using TPDomain.Models;

namespace TPDomain.DataTransferObjects
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
