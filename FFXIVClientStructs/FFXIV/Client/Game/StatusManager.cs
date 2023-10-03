namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe partial struct StatusManager {
    // This field is often null and cannot be relied on to retrieve the owning Character object
    [FieldOffset(0x0)] public Character.Character* Owner;
    [FixedSizeArray<Status>(60)]
    [FieldOffset(0x8)] public fixed byte Status[0xC * 60]; // Client::Game::Status array
    [FieldOffset(0x2D8)] public uint Flags1;
    [FieldOffset(0x2DC)] public ushort Flags2;
    [FieldOffset(0x2E0)] public long Unk_178;
    [FieldOffset(0x2E4)] public byte Unk_180;
    [FieldOffset(0x2E8)] public byte NumValidStatuses;

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 74 B7")]
    public partial bool HasStatus(uint statusId, uint sourceId = 0xE0000000);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 79 ?? 48 8B 15")]
    public partial int GetStatusIndex(uint statusId, uint sourceId = 0xE0000000);

    [MemberFunction("83 FA 3C 72 04 0F 57 C0")]
    public partial float GetRemainingTime(int statusIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 3D ?? ?? ?? ?? 74 45")]
    public partial uint GetStatusId(int statusIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 3B 44 24 28")]
    public partial uint GetSourceId(int statusIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B CE E8 ?? ?? ?? ?? 84 C0 74 4E")]
    public partial void AddStatus(ushort statusId, ushort param = 0, void* u3 = null);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FF 3C")]
    public partial void RemoveStatus(int statusIndex, byte u2 = 0); // u2 always appears to be 0
}
