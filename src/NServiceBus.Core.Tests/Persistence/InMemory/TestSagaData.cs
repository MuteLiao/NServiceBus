﻿namespace NServiceBus.SagaPersisters.InMemory.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class TestSaga : Saga<TestSagaData>, IAmStartedByMessages<StartMessage>
    {
        public Task Handle(StartMessage message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<TestSagaData> mapper)
        {
        }
    }

    class StartMessage
    {
    }

    public class TestSagaData : IContainSagaData
    {
        public RelatedClass RelatedClass { get; set; }

        public IList<OrderLine> OrderLines { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime DateTimeProperty { get; set; }

        public TestComponent TestComponent { get; set; }

        public PolymorphicPropertyBase PolymorphicRelatedProperty { get; set; }
        public Guid Id { get; set; }

        public string Originator { get; set; }

        public string OriginalMessageId { get; set; }
    }

    public class PolymorphicProperty : PolymorphicPropertyBase
    {
        public int SomeInt { get; set; }
    }

    public class PolymorphicPropertyBase
    {
        public Guid Id { get; set; }
    }

    public enum StatusEnum
    {
        SomeStatus,
        AnotherStatus
    }

    public class TestComponent
    {
        public string Property { get; set; }
        public string AnotherProperty { get; set; }
    }

    public class OrderLine
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
    }

    public class RelatedClass
    {
        public Guid Id { get; set; }

        public TestSagaData ParentSaga { get; set; }
    }
}