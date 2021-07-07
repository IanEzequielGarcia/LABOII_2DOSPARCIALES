﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ISerializa
    {
        bool XML();
        string Path { get;}
    }
    public interface IDeserializa
    {
        bool Xml(out Lapiz lapiz);
    }
}
