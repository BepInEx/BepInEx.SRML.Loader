﻿using SRML.SR.SaveSystem.Data;
using System;

namespace SRML.SR.SaveSystem.Utils
{
    internal static class ExtendedDataUtils
    {
        public static SRMod GetModForParticipant(ExtendedData.Participant p)
        {
            return SRModLoader.GetModForAssembly(p.GetType().Assembly);
        }

        public static int GetParticipantCount(CompoundDataPiece modPiece)
        {
            return modPiece.DataList.Count;
        }

        public static int GetModPieceCount(CompoundDataPiece root)
        {
            return root.DataList.Count;
        }

        public static CompoundDataPiece GetPieceForParticipant(string participantName, CompoundDataPiece piece)
        {
            return piece.GetCompoundPiece(participantName);
        }

        public static CompoundDataPiece GetPieceForParticipant(Type participantType, CompoundDataPiece piece)
        {
            return GetPieceForParticipant(GetParticipantName(participantType), piece);
        }

        public static CompoundDataPiece GetPieceForParticipant(ExtendedData.Participant p, CompoundDataPiece piece)
        {
            return GetPieceForParticipant(p.GetType(), piece);
        }

        public static CompoundDataPiece GetPieceForParticipantFromRoot(ExtendedData.Participant p, CompoundDataPiece piece)
        {
            return GetPieceForParticipantFromRoot(GetModForParticipant(p).ModInfo.Id, p, piece);
        }

        public static CompoundDataPiece GetPieceForParticipantFromRoot(string modid, ExtendedData.Participant p, CompoundDataPiece piece)
        {
            return GetPieceForParticipant(p, GetPieceForMod(modid, piece));
        }

        public static CompoundDataPiece GetPieceForParticipant<T>(CompoundDataPiece piece) where T : ExtendedData.Participant
        {
            return GetPieceForParticipant(typeof(T), piece);
        }

        public static CompoundDataPiece GetPieceForMod(String modid, CompoundDataPiece piece)
        {
            return piece.GetCompoundPiece(modid);
        }

        public static String GetParticipantName(Type t)
        {
            return t.FullName;
        }

        public static String GetParticipantName(ExtendedData.Participant p)
        {
            return GetParticipantName(p.GetType());
        }
    }
}