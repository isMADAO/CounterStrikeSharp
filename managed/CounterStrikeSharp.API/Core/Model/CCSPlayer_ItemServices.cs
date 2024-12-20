﻿/*
 *  This file is part of CounterStrikeSharp.
 *  CounterStrikeSharp is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  CounterStrikeSharp is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with CounterStrikeSharp.  If not, see <https://www.gnu.org/licenses/>. *
 */

using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Memory.DynamicFunctions;
using CounterStrikeSharp.API.Modules.Utils;

namespace CounterStrikeSharp.API.Core;

public partial class CCSPlayer_ItemServices
{
    /// <summary>
    /// Drops the active player weapon on the ground.
    /// </summary>
    /// <exception cref="InvalidOperationException">ItemServices points to null</exception>
    public void DropActivePlayerWeapon(CBasePlayerWeapon activeWeapon)
    {
        if(Handle == IntPtr.Zero)
            throw new InvalidOperationException("ItemServices points to null.");

        Guard.IsValidEntity(activeWeapon);

        VirtualFunction.CreateVoid<nint, nint>(Handle, GameData.GetOffset("CCSPlayer_ItemServices_DropActivePlayerWeapon"))(Handle, activeWeapon.Handle);
    }

    /// <summary>
    /// Removes every weapon from the player.
    /// </summary>
    /// <exception cref="InvalidOperationException">ItemServices points to null</exception>
    public void RemoveWeapons()
    {
        if (Handle == IntPtr.Zero)
            throw new InvalidOperationException("ItemServices points to null.");

        VirtualFunction.CreateVoid<nint>(Handle, GameData.GetOffset("CCSPlayer_ItemServices_RemoveWeapons"))(Handle);
    }

    public T? GiveNamedItem<T>(string item) where T : CEntityInstance
    {
        var pointer = VirtualFunction.Create<nint, string, nint>(Handle, GameData.GetOffset("CCSPlayer_ItemServices_GiveNamedItem"))(Handle, item);
        if (pointer == IntPtr.Zero)
            return null;

        return (T)Activator.CreateInstance(typeof(T), pointer)!;
    }

    public AcquireResult CanAcquire(CEconItemView itemView, AcquireMethod method, IntPtr unknown = 0)
    {
        return VirtualFunctions.CCSPlayer_ItemServices_CanAcquireFunc.Invoke(this, itemView, method, unknown);
    }
}
