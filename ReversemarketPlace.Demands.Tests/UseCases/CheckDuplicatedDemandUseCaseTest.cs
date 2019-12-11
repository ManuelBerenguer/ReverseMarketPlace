using ReversemarketPlace.Demands.Tests.TestData;
using ReverseMarketPlace.Demands.Core.Domain;
using ReverseMarketPlace.Demands.Core.UseCases.Demands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReversemarketPlace.Demands.Tests.UseCases
{
    public class CheckDuplicatedDemandUseCaseTest
    {
        private readonly CheckDuplicatedDemandUseCase _checkDuplicatedDemandUseCase;
        public CheckDuplicatedDemandUseCaseTest()
        {
            _checkDuplicatedDemandUseCase = new CheckDuplicatedDemandUseCase();
        }

        [Fact]
        public async Task T001_CollectionOfDemandsNullThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => _checkDuplicatedDemandUseCase.ExecuteAsync(null, null)
            );
        }

        [Fact]
        public async Task T002_DemandToCheckNullThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => _checkDuplicatedDemandUseCase.ExecuteAsync(new List<Demand>(), null)
            );
        }

        [Fact]
        public async Task T003_EmptyCollectionOfDemandsReturnsNotDuplicated()
        {            
            Assert.False(await _checkDuplicatedDemandUseCase.ExecuteAsync(new List<Demand>(), 
                TestDemandFactory.DEMAND_TELEVISIONS_WITHOUT_ATTRIBUTES()));
        }

        [Fact]
        public async Task T004_DemandWithProductTypeNotPresentInCollectionReturnsNotDuplicated()
        {
            var demandCollection = new List<Demand>() { TestDemandFactory.DEMAND_PRODUCTTYPE2_WITHOUT_ATTRIBUTES() };

            Assert.False(await _checkDuplicatedDemandUseCase.ExecuteAsync(demandCollection,
                TestDemandFactory.DEMAND_TELEVISIONS_WITHOUT_ATTRIBUTES()));
        }

        [Fact]
        public async Task T005_DemandWithProductTypePresentInCollectionBothWithoutAttributesReturnsDuplicated()
        {
            var demandCollection = new List<Demand>() { TestDemandFactory.DEMAND_TELEVISIONS_WITHOUT_ATTRIBUTES() };

            Assert.True(await _checkDuplicatedDemandUseCase.ExecuteAsync(demandCollection,
                TestDemandFactory.DEMAND_TELEVISIONS_WITHOUT_ATTRIBUTES()));
        }

        [Fact]
        public async Task T006_DemandWithoutAttributesAndTheOneInCollectionWithAttributesRetursNotDuplicated()
        {
            var demandCollection = new List<Demand>() { TestDemandFactory.DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_INCHES_55() };

            Assert.False(await _checkDuplicatedDemandUseCase.ExecuteAsync(demandCollection,
                TestDemandFactory.DEMAND_TELEVISIONS_WITHOUT_ATTRIBUTES()));
        }

        [Fact]
        public async Task T007_DemandWithAttributesAndTheOneInCollectionWithOutAttributesReturnsNotDuplicated()
        {
            var demandCollection = new List<Demand>();

            Assert.False(await _checkDuplicatedDemandUseCase.ExecuteAsync(demandCollection,
                TestDemandFactory.DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_INCHES_55()));
        }

        [Fact]
        public async Task T008_SameProductTypeAndDifferentNumberOfAttributesReturnsNotDuplicated()
        {
            var demandCollection = new List<Demand>() { TestDemandFactory.DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_INCHES_55() };

            Assert.False(await _checkDuplicatedDemandUseCase.ExecuteAsync(demandCollection,
                TestDemandFactory.DEMAND_PRODUCTTYPE2_WITH_TWO_ATTRIBUTES()));
        }

        [Fact]
        public async Task T008_SameProductTypeSameNumberOfAttributesButDifferentAttributesReturnsNotDuplicated()
        {
            var demandCollection = new List<Demand>() { TestDemandFactory.DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_INCHES_55() };

            Assert.False(await _checkDuplicatedDemandUseCase.ExecuteAsync(demandCollection,
                TestDemandFactory.DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_COLOR()));
        }

        [Fact]
        public async Task T008_SameProductTypeSameAttributesButDifferentValuesReturnsNotDuplicated()
        {
            var demandCollection = new List<Demand>() { TestDemandFactory.DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_INCHES_55() };

            Assert.False(await _checkDuplicatedDemandUseCase.ExecuteAsync(demandCollection,
                TestDemandFactory.DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_INCHES_50()));
        }
    }
}
