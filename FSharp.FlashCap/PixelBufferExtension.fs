﻿////////////////////////////////////////////////////////////////////////////
//
// FlashCap - Independent camera capture library.
// Copyright (c) Kouji Matsui (@kozy_kekyo, @kekyo@mastodon.cloud)
//
// Licensed under Apache-v2: https://opensource.org/licenses/Apache-2.0
//
////////////////////////////////////////////////////////////////////////////

namespace FlashCap

open System.Diagnostics

[<AutoOpen>]
module public PixelBufferExtension =

    type public PixelBuffer with

        member self.extractImage() =
            let image = self.InternalExtractImage(
                PixelBuffer.BufferStrategies.CopyWhenDifferentSizeOrReuse)
            do Debug.Assert(image.Array.Length = image.Count)
            image.Array

        member self.copyImage() =
            let image = self.InternalExtractImage(
                PixelBuffer.BufferStrategies.ForceCopy)
            do Debug.Assert(image.Array.Length = image.Count)
            image.Array

        member self.referImage() =
            self.InternalExtractImage(
                PixelBuffer.BufferStrategies.ForceReuse)
