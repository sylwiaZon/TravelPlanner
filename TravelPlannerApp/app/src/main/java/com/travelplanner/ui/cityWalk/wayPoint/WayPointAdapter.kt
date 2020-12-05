package com.travelplanner.ui.cityWalk.wayPoint

import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.ItineraryItem
import com.travelplanner.models.WayPoint
import com.travelplanner.ui.poi.PoiActivity
import com.travelplanner.ui.poi.PoiFragment

class WayPointAdapter : RecyclerView.Adapter<WayPointAdapter.ViewHolder>(){
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }
    private var wayPointsList:  List<WayPoint> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_way_point, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return wayPointsList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val title = holderView.findViewById<TextView>(R.id.way_point_poi_title)
        val description = holderView.findViewById<TextView>(R.id.way_point_poi_description)
        val walkDuration = holderView.findViewById<TextView>(R.id.item_way_point_walk_to_next_duration)
        val walkDistance = holderView.findViewById<TextView>(R.id.item_way_point_walk_to_next_distance)
        val visitTime = holderView.findViewById<TextView>(R.id.item_way_point_visit_time)
        walkDuration.text = wayPointsList[position].walkToNextDuration.toString()
        walkDistance.text = wayPointsList[position].walkToNextDistance.toString()
        visitTime.text = wayPointsList[position].visitTime.toString()
        title.text = wayPointsList[position].poi.name
        description.text = wayPointsList[position].poi.snippet
        val image = holderView.findViewById<ImageView>(R.id.way_point_image)
        if(wayPointsList[position].poi.photoUrl == null || wayPointsList[position].poi.photoUrl == "")
            image.visibility = View.GONE
        else
            Glide
                .with(holderView.context)
                .load(wayPointsList[position].poi.photoUrl)
                .into(image)
        val seePoi = holderView.findViewById<TextView>(R.id.day_plan_itinerary_see_poi)
        seePoi.setOnClickListener {
            val intent = Intent(holderView.context, PoiActivity::class.java)
            intent.putExtra(PoiFragment.EXTRA_POI, wayPointsList[position].poi)
            holderView.context.startActivity(intent)
        }
    }

    public fun setData(data: List<WayPoint>){
        wayPointsList = data
        notifyDataSetChanged()
    }
}