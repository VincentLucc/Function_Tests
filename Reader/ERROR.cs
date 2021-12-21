// Decompiled with JetBrains decompiler
// Type: Reader.ERROR
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

namespace Reader
{
  public class ERROR
  {
    public const byte SUCCESS = (byte) 16;
    public const byte FAIL = (byte) 17;
    public const byte MCU_RESET_ERROR = (byte) 32;
    public const byte CW_ON_ERROR = (byte) 33;
    public const byte ANTENNA_MISSING_ERROR = (byte) 34;
    public const byte WRITE_FLASH_ERROR = (byte) 35;
    public const byte READ_FLASH_ERROR = (byte) 36;
    public const byte SET_OUTPUT_POWER_ERROR = (byte) 37;
    public const byte TAG_INVENTORY_ERROR = (byte) 49;
    public const byte TAG_READ_ERROR = (byte) 50;
    public const byte TAG_WRITE_ERROR = (byte) 51;
    public const byte TAG_LOCK_ERROR = (byte) 52;
    public const byte TAG_KILL_ERROR = (byte) 53;
    public const byte NO_TAG_ERROR = (byte) 54;
    public const byte INVENTORY_OK_BUT_ACCESS_FAIL = (byte) 55;
    public const byte BUFFER_IS_EMPTY_ERROR = (byte) 56;
    public const byte ACCESS_OR_PASSWORD_ERROR = (byte) 64;
    public const byte PARAMETER_INVALID = (byte) 65;
    public const byte PARAMETER_INVALID_WORDCNT_TOO_LONG = (byte) 66;
    public const byte PARAMETER_INVALID_MEMBANK_OUT_OF_RANGE = (byte) 67;
    public const byte PARAMETER_INVALID_LOCK_REGION_OUT_OF_RANGE = (byte) 68;
    public const byte PARAMETER_INVALID_LOCK_ACTION_OUT_OF_RANGE = (byte) 69;
    public const byte PARAMETER_READER_ADDRESS_INVALID = (byte) 70;
    public const byte PARAMETER_INVALID_ANTENNA_ID_OUT_OF_RANGE = (byte) 71;
    public const byte PARAMETER_INVALID_OUTPUT_POWER_OUT_OF_RANGE = (byte) 72;
    public const byte PARAMETER_INVALID_FREQUENCY_REGION_OUT_OF_RANGE = (byte) 73;
    public const byte PARAMETER_INVALID_BAUDRATE_OUT_OF_RANGE = (byte) 74;
    public const byte PARAMETER_BEEPER_MODE_OUT_OF_RANGE = (byte) 75;
    public const byte PARAMETER_EPC_MATCH_LEN_TOO_LONG = (byte) 76;
    public const byte PARAMETER_EPC_MATCH_LEN_ERROR = (byte) 77;
    public const byte PARAMETER_INVALID_EPC_MATCH_MODE = (byte) 78;
    public const byte PARAMETER_INVALID_FREQUENCY_RANGE = (byte) 79;
    public const byte FAIL_TO_GET_RN16_FROM_TAG = (byte) 80;
    public const byte PARAMETER_INVALID_DRM_MODE = (byte) 81;
    public const byte PLL_LOCK_FAIL = (byte) 82;
    public const byte RF_CHIP_FAIL_TO_RESPONSE = (byte) 83;
    public const byte FAIL_TO_ACHIEVE_DESIRED_OUTPUT_POWER = (byte) 84;
    public const byte COPYRIGHT_AUTHENTICATION_FAIL = (byte) 85;
    public const byte SPECTRUM_REGULATION_ERROR = (byte) 86;
    public const byte OUTPUT_POWER_TOO_LOW = (byte) 87;
    public const byte UNKONW_ERROR = (byte) 88;

    public static string format(byte btErrorCode)
    {
      string str;
      switch (btErrorCode)
      {
        case (byte) 16:
          str = "Command succeeded.";
          break;
        case (byte) 17:
          str = "Command failed.";
          break;
        case (byte) 32:
          str = "CPU reset error.";
          break;
        case (byte) 33:
          str = "Turn on CW error.";
          break;
        case (byte) 34:
          str = "Antenna is missing.";
          break;
        case (byte) 35:
          str = "Write flash error.";
          break;
        case (byte) 36:
          str = "Read flash error.";
          break;
        case (byte) 37:
          str = "Set output power error.";
          break;
        case (byte) 49:
          str = "Error occurred when inventory.";
          break;
        case (byte) 50:
          str = "Error occurred when read.";
          break;
        case (byte) 51:
          str = "Error occurred when write.";
          break;
        case (byte) 52:
          str = "Error occurred when lock.";
          break;
        case (byte) 53:
          str = "Error occurred when kill.";
          break;
        case (byte) 54:
          str = "There is no tag to be operated.";
          break;
        case (byte) 55:
          str = "Tag Inventoried but access failed.";
          break;
        case (byte) 56:
          str = "Buffer is empty.";
          break;
        case (byte) 64:
          str = "Access failed or wrong password.";
          break;
        case (byte) 65:
          str = "Invalid parameter.";
          break;
        case (byte) 66:
          str = "WordCnt is too long.";
          break;
        case (byte) 67:
          str = "MemBank out of range.";
          break;
        case (byte) 68:
          str = "Lock region out of range.";
          break;
        case (byte) 69:
          str = "LockType out of range.";
          break;
        case (byte) 70:
          str = "Invalid reader address.";
          break;
        case (byte) 71:
          str = "AntennaID out of range.";
          break;
        case (byte) 72:
          str = "Output power out of range.";
          break;
        case (byte) 73:
          str = "Frequency region out of range.";
          break;
        case (byte) 74:
          str = "Baud rate out of range.";
          break;
        case (byte) 75:
          str = "Buzzer behavior out of range.";
          break;
        case (byte) 76:
          str = "EPC match is too long.";
          break;
        case (byte) 77:
          str = "EPC match length wrong.";
          break;
        case (byte) 78:
          str = "Invalid EPC match mode.";
          break;
        case (byte) 79:
          str = "Invalid frequency range.";
          break;
        case (byte) 80:
          str = "Failed to receive RN16 from tag.";
          break;
        case (byte) 81:
          str = "Invalid DRM mode.";
          break;
        case (byte) 82:
          str = "PLL can not lock.";
          break;
        case (byte) 83:
          str = "No response from RF chip.";
          break;
        case (byte) 84:
          str = "Can’t achieve desired output power level.";
          break;
        case (byte) 85:
          str = "Can’t authenticate firmware copyright.";
          break;
        case (byte) 86:
          str = "Spectrum regulation wrong.";
          break;
        case (byte) 87:
          str = "Output power too low.";
          break;
        default:
          str = "Unknown Error";
          break;
      }
      return str;
    }
  }
}
