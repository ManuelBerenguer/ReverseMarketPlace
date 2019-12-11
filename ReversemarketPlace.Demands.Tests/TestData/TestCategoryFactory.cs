using ReverseMarketPlace.Demands.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversemarketPlace.Demands.Tests.TestData
{
    internal static class TestCategoryFactory
    {
        internal static Guid CATEGORY_TV_AND_AUDIO_GUID()
        {
            return new Guid(Constants.CATEGORY_TV_AND_AUDIO_GUID);
        }

        internal static Category CATEGORY_TV_AND_AUDIO()
        {
            return new Category(CATEGORY_TV_AND_AUDIO_GUID(), Constants.CATEGORY_TV_AND_AUDIO, null, null);
        }

        internal static Guid CATEGORY_TV_GUID()
        {
            return new Guid(Constants.CATEGORY_TV_GUID);
        }

        internal static Category CATEGORY_TV()
        {
            return new Category(CATEGORY_TV_GUID(), Constants.CATEGORY_TV, CATEGORY_TV_AND_AUDIO(), null);
        }

        internal static Guid CATEGORY_AUDIO_GUID()
        {
            return new Guid(Constants.CATEGORY_AUDIO_GUID);
        }

        internal static Category CATEGORY_AUDIO()
        {
            return new Category(CATEGORY_AUDIO_GUID(), Constants.CATEGORY_AUDIO, CATEGORY_TV_AND_AUDIO(), null);
        }
    }
}
