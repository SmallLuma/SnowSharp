#include "Util.h"

System::Byte ParseCompressMode(std::string mode)
{
	System::Byte ret;
	if (mode == "RGBA")
		ret = 0;
	else if (mode == "RGB")
		ret = 1;
	else if (mode == "DXT1")
		ret = 10;
	else if (mode == "DXT3")
		ret = 11;
	else if (mode == "DXT5")
		ret = 12;
	return ret;
}
