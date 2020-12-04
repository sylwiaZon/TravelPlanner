package com.travelplanner.models

import android.os.Parcel
import android.os.Parcelable
import java.time.LocalDateTime

class Travel(val travelId: String, val arrivalDate: LocalDateTime, val departureDate: LocalDateTime, val participants: TravelParticipants, val travelDestination: TravelDestination, val photoUrl: String) : Parcelable {
    constructor(parcel: Parcel) : this(
            parcel.readString()?: "",
            LocalDateTime.parse(parcel.readString()?:""),
            LocalDateTime.parse(parcel.readString()?:""),
            parcel.readParcelable<TravelParticipants>(TravelParticipants::class.java.classLoader)?: TravelParticipants(0, emptyList(),0),
            parcel.readParcelable<TravelDestination>(TravelDestination::class.java.classLoader)?: TravelDestination("", ""),
            parcel.readString()?:"") {
    }

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeString(travelId)
        parcel.writeString(arrivalDate.toString())
        parcel.writeString(departureDate.toString())
        parcel.writeParcelable(participants, flags)
        parcel.writeParcelable(travelDestination, flags)
        parcel.writeString(photoUrl)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Travel> {
        override fun createFromParcel(parcel: Parcel): Travel {
            return Travel(parcel)
        }

        override fun newArray(size: Int): Array<Travel?> {
            return arrayOfNulls(size)
        }
    }
}

class TravelDestination(val city: String, val country: String) : Parcelable {
    constructor(parcel: Parcel) : this(
            parcel.readString()?:"",
            parcel.readString()?:"") {
    }

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeString(city)
        parcel.writeString(country)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<TravelDestination> {
        override fun createFromParcel(parcel: Parcel): TravelDestination {
            return TravelDestination(parcel)
        }

        override fun newArray(size: Int): Array<TravelDestination?> {
            return arrayOfNulls(size)
        }
    }
}

class TravelParticipants(val children: Int, val childrenAges: List<Int>?, val adults: Int ) : Parcelable {
    constructor(parcel: Parcel) : this(
            parcel.readInt(),
            intArrayOf().apply { parcel.readIntArray(this) }.toList(),
            parcel.readInt()) {
    }

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(children)
        parcel.writeIntArray(childrenAges?.toIntArray()?: intArrayOf())
        parcel.writeInt(adults)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<TravelParticipants> {
        override fun createFromParcel(parcel: Parcel): TravelParticipants {
            return TravelParticipants(parcel)
        }

        override fun newArray(size: Int): Array<TravelParticipants?> {
            return arrayOfNulls(size)
        }
    }
}