package com.travelplanner.ui.cityWalk

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.models.CityWalk
import com.travelplanner.models.Itinerary
import com.travelplanner.ui.cityWalk.wayPoint.WayPointAdapter
import com.travelplanner.ui.dayPlan.itinerary.ItineraryAdapter
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class CityWalkAdapter() : RecyclerView.Adapter<CityWalkAdapter.ViewHolder>() {

    class ViewHolder(itemView: View, var isOpen: Boolean) : RecyclerView.ViewHolder(itemView) {

    }
    private var cityWalksList:  List<CityWalk> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_city_walk, parent, false)
        return ViewHolder(itemView, false)
    }

    override fun getItemCount(): Int {
        return cityWalksList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val recycler = holderView.findViewById<RecyclerView>(R.id.way_point_recycler)
        val adapter = WayPointAdapter()
        cityWalksList[position].wayPoints?.let {
            adapter.setData(it)
        }
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(holderView.context)
        val downArrow = holderView.findViewById<ImageView>(R.id.way_points_arrow_down)
        val upArrow = holderView.findViewById<ImageView>(R.id.way_points_arrow_up)
        if(!holder.isOpen){
            upArrow.visibility = View.GONE
            downArrow.visibility = View.VISIBLE
            recycler.visibility = View.GONE
        } else {
            upArrow.visibility = View.VISIBLE
            downArrow.visibility = View.GONE
            recycler.visibility = View.VISIBLE
        }
        holderView.setOnClickListener{
            if(!holder.isOpen) {
                holder.isOpen = true
                upArrow.visibility = View.GONE
                downArrow.visibility = View.VISIBLE
                recycler.visibility = View.GONE
            } else {
                holder.isOpen = false
                upArrow.visibility = View.VISIBLE
                downArrow.visibility = View.GONE
                recycler.visibility = View.VISIBLE
            }
        }
        val walkDuration = holderView.findViewById<TextView>(R.id.walk_duration)
        val walkDistance = holderView.findViewById<TextView>(R.id.walk_distance)
        val totalDuration = holderView.findViewById<TextView>(R.id.total_duration)
        walkDuration.text = cityWalksList[position].walkDuration.toString()
        walkDistance.text = cityWalksList[position].walkDistance.toString()
        totalDuration.text = cityWalksList[position].totalDuration.toString()
    }

    public fun setData(data: List<CityWalk>){
        cityWalksList = data
        notifyDataSetChanged()
    }
}