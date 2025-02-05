﻿using EndFieldPS.Protocol;
using EndFieldPS.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EndFieldPS.Resource.ResourceManager;

namespace EndFieldPS.Game.Entities
{
    public class EntityNpc : Entity
    {
        public string templateId;
        public EntityNpc()
        {

        }
        public EntityNpc(string templateId, ulong worldOwner, Vector3f pos, Vector3f rot,ulong guid)
        {
            this.guid = (ulong)guid;
            this.level = 1;
            this.worldOwner = worldOwner;
            this.Position = pos;
            this.Rotation = rot;
            this.templateId = templateId;
        }
        
        
        public SceneNpc ToProto()
        {
            SceneNpc proto = new SceneNpc()
            {
                CommonInfo = new()
                {
                    Hp = 100,
                    Id = guid,
                    Templateid = templateId,

                    SceneNumId = GetOwner().curSceneNumId,
                    Position = Position.ToProto(),
                    Rotation = Rotation.ToProto(),

                    Type = 0, 
                },


            };
            return proto;
        }
        public override void Damage(double dmg)
        {
            
        }

        public override void Heal(double heal)
        {
            
        }

    }
}
