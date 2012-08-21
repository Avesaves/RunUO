using System;
using Server;
using Server.Engines.Craft;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x0FBF, 0x0FC0 )]
	public class ScribesPen : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefInscription.CraftSystem; } }

		public override int LabelNumber{ get{ return 1044168; } } // scribe's pen

		[Constructable]
		public ScribesPen() : base( 0x0FBF )
		{
			Weight = 1.0;
		}

		[Constructable]
		public ScribesPen( int uses ) : base( uses, 0x0FBF )
		{
			Weight = 1.0;
		}

		public ScribesPen( Serial serial ) : base( serial )
		{
		}

        public override void OnSingleClick(Mobile from)
        {
            if (this.Name != null)
            {
                from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", this.Name));
            }
            else
            {
                from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", "a scribe's pen"));
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 2.0 )
				Weight = 1.0;
		}
	}
}