package com.travelplanner.models

import android.os.Parcel
import android.os.Parcelable

class Poi(val poiId: String, val price: String, val currency: String, val latitude: Float,
          val longitude: Float, val id: String, val intro: String, val locationId: String,
          val name: String, val score: Float, val snippet: String, val attributions: List<Attribution>?,
         val photoUrl: String, val vendorUrl: String) : Parcelable {
    constructor(parcel: Parcel) : this(
            parcel.readString()?:"",
            parcel.readString()?:"",
            parcel.readString()?:"",
            parcel.readFloat(),
            parcel.readFloat(),
            parcel.readString()?:"",
            parcel.readString()?:"",
            parcel.readString()?:"",
            parcel.readString()?:"",
            parcel.readFloat(),
            parcel.readString()?:"",
            arrayListOf<Attribution>().apply {
                parcel.readList(this, Attribution::class.java.classLoader)
            },
            parcel.readString()?:"",
            parcel.readString()?:"") {
    }

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeString(poiId)
        parcel.writeString(price)
        parcel.writeString(currency)
        parcel.writeFloat(latitude)
        parcel.writeFloat(longitude)
        parcel.writeString(id)
        parcel.writeString(intro)
        parcel.writeString(locationId)
        parcel.writeString(name)
        parcel.writeFloat(score)
        parcel.writeString(snippet)
        parcel.writeArray(attributions?.toTypedArray()?: arrayOf())
        parcel.writeString(photoUrl)
        parcel.writeString(vendorUrl)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Poi> {
        override fun createFromParcel(parcel: Parcel): Poi {
            return Poi(parcel)
        }

        override fun newArray(size: Int): Array<Poi?> {
            return arrayOfNulls(size)
        }
    }
}

class Attribution(val url: String, val source: String) : Parcelable {
    constructor(parcel: Parcel) : this(
            parcel.readString()?:"",
            parcel.readString()?:"") {
    }

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeString(url)
        parcel.writeString(source)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Attribution> {
        override fun createFromParcel(parcel: Parcel): Attribution {
            return Attribution(parcel)
        }

        override fun newArray(size: Int): Array<Attribution?> {
            return arrayOfNulls(size)
        }
    }
}