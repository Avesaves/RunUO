using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class ParalyzeScroll : SpellScroll
	{
		[Constructable]
		public ParalyzeScroll() : this( 1 )
		{
		}

		[Constructable]
		public ParalyzeScroll( int amount ) : base( 37, 0x1F52, amount )
		{
		}
		
		public ParalyzeScroll( Serial serial ) : base( serial )
		{
		}

        public override void OnSingleClick(Mobile from)
        {
            if (this.Name != null)
            {
                if (Amount >= 2)
                {
                    from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", Amount + " " + this.Name));
                }
                else
                {
                    from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", this.Name));
                }
            }
            else
            {
                if (Amount >= 2)
                {
                    from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", Amount + " Paralyze scrolls"));
                }
                else
                {
                    from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", "a Paralyze scroll"));
                }
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
		}
	}
}