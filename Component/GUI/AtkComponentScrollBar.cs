﻿using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{
    // Component::GUI::AtkComponentScrollBar
    //   Component::GUI::AtkComponentBase
    //     Component::GUI::AtkEventListener

    // size = 0x140
    // common CreateAtkComponent function 8B FA 33 DB E8 ? ? ? ? 
    // type ?
    [StructLayout(LayoutKind.Explicit, Size = 0x140)]
    public unsafe struct AtkComponentScrollBar
    {
        [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;
    }
}
