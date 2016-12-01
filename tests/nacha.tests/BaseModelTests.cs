﻿using CMS.Nacha.Constants;
using CMS.Nacha.Enums;
using CMS.Nacha.Models;
using Xunit;

namespace CMS.Nacha.Tests
{
    public class BaseModelTests
    {
        private class MyTestBaseModel : BaseModel
        {
            public MyTestBaseModel(short recordType)
            {
                RecordType = recordType;
            }
        }

        [Fact]
        public void BaseModel_InvalidRecordTypeRaises()
        {
            var _exception = Record.Exception(() =>
            {
                var _sut = new MyTestBaseModel(-999);
            }
            );

            Assert.NotNull(_exception);
            Assert.Equal(ExceptionConstants.DotNet_ArgumentOutOfRangeException + 
                ExceptionConstants.BaseModel_RecordTypeInvalid, _exception.Message);
        }

        [Fact]
        public void BaseModel_ValidRecordTypeSucceeds()
        {
            var _sut = new MyTestBaseModel((short)RecordTypeEnum.FileHeader);
        }
    }


}
