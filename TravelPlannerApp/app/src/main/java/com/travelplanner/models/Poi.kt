package com.travelplanner.models

class Poi(val poiId: String, val price: String, val currency: String, val latitude: Float,
          val longitude: Float, val id: String, val intro: String, val locationId: String,
          val name: String, val score: Float, val snippet: String, val attributions: List<Attribution>,
         val photoUrl: String, val vendorUrl: String)

class Attribution(val url: String, val source: String)