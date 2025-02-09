﻿using EndFieldPS.Network;
using EndFieldPS.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EndFieldPS.Packets.Sc
{
    public class PacketScSyncFullDungeonStatus : Packet
    {

        public PacketScSyncFullDungeonStatus(Player session) {
            ScSyncFullDungeonStatus dungeonStatus = new()
            {
                CurStamina = session.curStamina,
                MaxStamina = session.maxStamina,
                NextRecoverTime = session.nextRecoverTime / 1000,
            };

            SetData(ScMessageId.ScSyncFullDungeonStatus, dungeonStatus);
        }

    }
}
