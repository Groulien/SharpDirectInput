using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DWORD = System.UInt32;
namespace SharpDirectInput {
    public unsafe struct CustomDataFormat {
        public DWORD dwSize;
        public DWORD dwObjSize;
        public DWORD dwFlags;
        public DWORD dwDataSize;
        public DWORD dwNumObjs;
        public ObjectDataFormat* rgodf;
    }
}
