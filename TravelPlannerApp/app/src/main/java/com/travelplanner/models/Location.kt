package com.travelplanner.models

class Location(val locationId: String, val latitude: String, val longitude: String,
              val countryId: String, val intro: String, val name: String,
              val names: List<String>, val parentId: String, val partOf: List<String>,
              val score: Float, val snippet: String, val tagLabels: List<String>,
              val type: String, val photoUrl: String)