﻿using System;

namespace SqlBuilder.Attributes
{

	public class InsertDefaultAttribute : Attribute
	{

		public string DefaultValue { get; set; }

		public InsertDefaultAttribute(string defaultValue)
		{
			this.DefaultValue = defaultValue;
		}

	}

}