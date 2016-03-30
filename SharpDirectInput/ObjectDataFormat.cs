using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DWORD = System.UInt32;
namespace SharpDirectInput {
    //untested
    public unsafe struct ObjectDataFormat {
        public Guid *pguid;
        public DWORD   dwOfs;
        public DWORD   dwType;
        public DWORD   dwFlags;
    }
}
