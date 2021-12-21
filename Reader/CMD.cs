// Decompiled with JetBrains decompiler
// Type: Reader.CMD
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

namespace Reader
{
  public class CMD
  {
    public const byte RESET = (byte) 112;
    public const byte SET_UART_BAUDRATE = (byte) 113;
    public const byte GET_FIRMWARE_VERSION = (byte) 114;
    public const byte SET_READER_ADDRESS = (byte) 115;
    public const byte SET_WORK_ANTENNA = (byte) 116;
    public const byte GET_WORK_ANTENNA = (byte) 117;
    public const byte SET_OUTPUT_POWER = (byte) 118;
    public const byte GET_OUTPUT_POWER = (byte) 119;
    public const byte SET_FREQUENCY_REGION = (byte) 120;
    public const byte GET_FREQUENCY_REGION = (byte) 121;
    public const byte SET_BEEPER_MODE = (byte) 122;
    public const byte GET_READER_TEMPERATURE = (byte) 123;
    public const byte READ_GPIO_VALUE = (byte) 96;
    public const byte WRITE_GPIO_VALUE = (byte) 97;
    public const byte SET_ANT_CONNECTION_DETECTOR = (byte) 98;
    public const byte GET_ANT_CONNECTION_DETECTOR = (byte) 99;
    public const byte SET_TEMPORARY_OUTPUT_POWER = (byte) 102;
    public const byte SET_READER_IDENTIFIER = (byte) 103;
    public const byte GET_READER_IDENTIFIER = (byte) 104;
    public const byte SET_RF_LINK_PROFILE = (byte) 105;
    public const byte GET_RF_LINK_PROFILE = (byte) 106;
    public const byte GET_RF_PORT_RETURN_LOSS = (byte) 126;
    public const byte INVENTORY = (byte) 128;
    public const byte READ_TAG = (byte) 129;
    public const byte WRITE_TAG = (byte) 130;
    public const byte LOCK_TAG = (byte) 131;
    public const byte KILL_TAG = (byte) 132;
    public const byte SET_ACCESS_EPC_MATCH = (byte) 133;
    public const byte GET_ACCESS_EPC_MATCH = (byte) 134;
    public const byte REAL_TIME_INVENTORY = (byte) 137;
    public const byte FAST_SWITCH_ANT_INVENTORY = (byte) 138;
    public const byte CUSTOMIZED_SESSION_TARGET_INVENTORY = (byte) 139;
    public const byte SET_IMPINJ_FAST_TID = (byte) 140;
    public const byte SET_AND_SAVE_IMPINJ_FAST_TID = (byte) 141;
    public const byte GET_IMPINJ_FAST_TID = (byte) 142;
    public const byte ISO18000_6B_INVENTORY = (byte) 176;
    public const byte ISO18000_6B_READ_TAG = (byte) 177;
    public const byte ISO18000_6B_WRITE_TAG = (byte) 178;
    public const byte ISO18000_6B_LOCK_TAG = (byte) 179;
    public const byte ISO18000_6B_QUERY_LOCK_TAG = (byte) 180;
    public const byte GET_INVENTORY_BUFFER = (byte) 144;
    public const byte GET_AND_RESET_INVENTORY_BUFFER = (byte) 145;
    public const byte GET_INVENTORY_BUFFER_TAG_COUNT = (byte) 146;
    public const byte RESET_INVENTORY_BUFFER = (byte) 147;
    public const byte OPERATE_TAG_MASK = (byte) 152;

    public static string format(byte btCmd)
    {
      string str;
      switch (btCmd)
      {
        case (byte) 96:
          str = "Get GPIO1, GPIO2 status.";
          break;
        case (byte) 97:
          str = "Set GPIO3, GPIO4 status.";
          break;
        case (byte) 98:
          str = "Set antenna detector status.";
          break;
        case (byte) 99:
          str = "Get antenna detector status.";
          break;
        case (byte) 102:
          str = "Set RF power without saving to flash.";
          break;
        case (byte) 103:
          str = "Set reader’s identification bytes.";
          break;
        case (byte) 104:
          str = "Get reader’s identification bytes.";
          break;
        case (byte) 105:
          str = "Set RF link profile.";
          break;
        case (byte) 106:
          str = "Get RF link profile.";
          break;
        case (byte) 112:
          str = "Reset reader.";
          break;
        case (byte) 113:
          str = "Set baud rate of serial port.";
          break;
        case (byte) 114:
          str = "Get firmware version.";
          break;
        case (byte) 115:
          str = "Set reader’s address.";
          break;
        case (byte) 116:
          str = "Set working antenna.";
          break;
        case (byte) 117:
          str = "Query current working antenna.";
          break;
        case (byte) 118:
          str = "Set RF output power.";
          break;
        case (byte) 119:
          str = "Query current RF output power.";
          break;
        case (byte) 120:
          str = "Set RF frequency spectrum.";
          break;
        case (byte) 121:
          str = "Query RF frequency spectrum.";
          break;
        case (byte) 122:
          str = "Set reader’s buzzer hehavior.";
          break;
        case (byte) 123:
          str = "Check reader’s internal temperature.";
          break;
        case (byte) 126:
          str = "Get current antenna port’s return loss.";
          break;
        case (byte) 128:
          str = "Inventory EPC C1G2 tags to buffer.";
          break;
        case (byte) 129:
          str = "Read EPC C1G2 tag(s).";
          break;
        case (byte) 130:
          str = "Write EPC C1G2 tag(s).";
          break;
        case (byte) 131:
          str = "Lock EPC C1G2 tag(s).";
          break;
        case (byte) 132:
          str = "Kill EPC C1G2 tag(s).";
          break;
        case (byte) 133:
          str = "Set tag access filter by EPC.";
          break;
        case (byte) 134:
          str = "Query access filter by EPC.";
          break;
        case (byte) 137:
          str = "Inventory tags in real time mode.";
          break;
        case (byte) 138:
          str = "Real time inventory with fast ant switch.";
          break;
        case (byte) 139:
          str = "Inventory with desired session and inventoried flag.";
          break;
        case (byte) 140:
          str = "Set impinj FastTID function(Without saving to FLASH).";
          break;
        case (byte) 141:
          str = "Set impinj FastTID function(Save to FLASH).";
          break;
        case (byte) 142:
          str = "Get current FastTID setting.";
          break;
        case (byte) 144:
          str = "Get buffered data without clearing.";
          break;
        case (byte) 145:
          str = "Get and clear buffered data.";
          break;
        case (byte) 146:
          str = "Query how many tags are buffered.";
          break;
        case (byte) 147:
          str = "Clear buffer.";
          break;
        case (byte) 176:
          str = "Inventory 18000-6B tag(s).";
          break;
        case (byte) 177:
          str = "Read 18000-6B tag.";
          break;
        case (byte) 178:
          str = "Write 18000-6B tag.";
          break;
        case (byte) 179:
          str = "Lock 18000-6B tag data byte.";
          break;
        case (byte) 180:
          str = "Query lock 18000-6B tag data byte.";
          break;
        default:
          str = "Unknown error.";
          break;
      }
      return str;
    }
  }
}
