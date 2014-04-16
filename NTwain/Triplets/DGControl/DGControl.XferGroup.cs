﻿using System;
using NTwain.Data;
using NTwain.Values;

namespace NTwain.Triplets
{
    /// <summary>
    /// Represents <see cref="DataArgumentType.XferGroup"/>.
    /// </summary>
	public sealed class XferGroup : OpBase
	{
		internal XferGroup(ITwainStateInternal session) : base(session) { }

		/// <summary>
		/// Returns the Data Group (the type of data) for the upcoming transfer. The Source is required to
		/// only supply one of the DGs specified in the SupportedGroups field of origin.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
        public ReturnCode Get(ref DataGroups value)
		{
            Session.VerifyState(4, 6, DataGroups.Control, DataArgumentType.XferGroup, Message.Get);
            return Dsm.DsmEntry(Session.AppId, Session.SourceId, DataGroups.Control, DataArgumentType.XferGroup, Message.Get, ref value);
		}

        /// <summary>
        /// The transfer group determines the kind of data being passed from the Source to the Application.
        /// By default a TWAIN Source must default to DG_IMAGE. Currently the only other data group
        /// supported is DG_AUDIO, which is a feature supported by some digital cameras.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public ReturnCode Set(DataGroups value)
		{
			Session.VerifyState(6, 6, DataGroups.Control, DataArgumentType.XferGroup, Message.Set);
            return Dsm.DsmEntry(Session.AppId, Session.SourceId, DataGroups.Control, DataArgumentType.XferGroup, Message.Set, ref value);
		}
	}
}