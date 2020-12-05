package com.travelplanner.models

class CityWalk(val cityWalkId: String, val seed: Int, val totalDuration: Int, val walkDuration: Int, val walkDistance: Int, val wayPoints: List<WayPoint>)

class WayPoint(val wayPointId: String, val latitude: Float, val longitude: Float, val poi: Poi, val visitTime: Int, val walkToNextDistance: Int, val walkToNextDuration: Int)