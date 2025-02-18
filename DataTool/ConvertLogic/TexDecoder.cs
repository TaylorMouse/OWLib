﻿using System;
using AssetRipper.TextureDecoder.Bc;
using AssetRipper.TextureDecoder.Rgb;
using AssetRipper.TextureDecoder.Rgb.Formats;
using JetBrains.Annotations;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using TankLib;

namespace DataTool.ConvertLogic {
    public class TexDecoder {
        public Memory<byte> PixelData { get; set; }
        public int Pixels { get; set; }
        public uint Surfaces { get; set; }
        public teTexture Texture { get; set; }

        public TexDecoder(teTexture texture) {
            Texture = texture;
            Pixels = Texture.Header.Width * Texture.Header.Height * 4;
            Surfaces = texture.Header.Surfaces;

            var format = (TextureTypes.DXGI_PIXEL_FORMAT) texture.Header.Format;
            var allData = Texture.GetData();
            PixelData = new byte[Pixels * Surfaces * 4].AsMemory();
            var size = (int) (allData.Length / Surfaces);

            for (var surface = 0; surface < Surfaces; ++surface) {
                var data = allData.Slice(size * surface, size);
                var interm = PixelData.Slice(Pixels * surface, Pixels).Span;
                switch (format) {
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT: {
                        RgbConverter.Convert<ColorRGBA128Single, float, ColorBGRA32, byte>(data, Texture.Header.Width, Texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT: {
                        RgbConverter.Convert<ColorRGBA64Half, Half, ColorBGRA32, byte>(data, Texture.Header.Width, Texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R16G16_FLOAT: {
                        RgbConverter.Convert<ColorR16Half, Half, ColorBGRA32, byte>(data, Texture.Header.Width, Texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R16_FLOAT: {
                        RgbConverter.Convert<ColorR16Half, Half, ColorBGRA32, byte>(data, Texture.Header.Width, Texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R16G16B16A16_UNORM:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R16G16B16A16_SNORM:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R16G16B16A16_UINT:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R16G16B16A16_SINT: {
                        RgbConverter.Convert<ColorRGBA64, ushort, ColorBGRA32, byte>(data, Texture.Header.Width, Texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R11G11B10_FLOAT:{
                        RgbConverter.Convert<ColorRGB32Half, Half, ColorBGRA32, byte>(data, Texture.Header.Width, Texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM_SRGB:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8G8B8A8_UINT:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8G8B8A8_SINT: {
                        RgbConverter.Convert<ColorRGBA32, byte, ColorBGRA32, byte>(data, Texture.Header.Width, Texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8G8_UNORM:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8G8_UINT:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8G8_SINT: {
                        RgbConverter.Convert<ColorRG16, byte, ColorBGRA32, byte>(data, Texture.Header.Width, Texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8_UNORM:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8_SNORM:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8_UINT:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_R8_SINT: {
                        RgbConverter.Convert<ColorR8, byte, ColorBGRA32, byte>(data, Texture.Header.Width, Texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_BC1_UNORM:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB: {
                        BcDecoder.DecompressBC1(data, texture.Header.Width, texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_BC4_UNORM: {
                        BcDecoder.DecompressBC4(data, texture.Header.Width, texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_BC5_UNORM: {
                        BcDecoder.DecompressBC5(data, texture.Header.Width, texture.Header.Height, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_BC6H_UF16:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_BC6H_SF16: {
                        BcDecoder.DecompressBC6H(data, texture.Header.Width, texture.Header.Height, format is TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_BC6H_SF16, interm);
                        break;
                    }
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_BC7_UNORM:
                    case TextureTypes.DXGI_PIXEL_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB: {
                        BcDecoder.DecompressBC7(data, texture.Header.Width, texture.Header.Height, interm);
                        break;
                    }
                    default:
                        throw new NotImplementedException($"Unsupported format {format}");
                }
            }
        }

        public Image<Bgra32> GetSheet() {
            return Image.LoadPixelData<Bgra32>(PixelData.Span, Texture.Header.Width, (int) (Texture.Header.Height * Surfaces));
        }

        [CanBeNull]
        public Image<Bgra32> GetFrame(int frame) {
            return frame >= Surfaces ? null : Image.LoadPixelData<Bgra32>(PixelData.Slice(Pixels * frame, Pixels).Span, Texture.Header.Width, Texture.Header.Height);
        }
    }
}