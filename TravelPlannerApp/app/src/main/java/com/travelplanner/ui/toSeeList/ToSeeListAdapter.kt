package com.travelplanner.ui.toSeeList

import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.ToSeeItem
import com.travelplanner.ui.localHighlights.LocalHighlightsAdapter
import com.travelplanner.ui.poi.PoiActivity
import com.travelplanner.ui.poi.PoiFragment

class ToSeeListAdapter(val travelId: String?, val onChecked: (poiId: ToSeeItem) -> Unit) : RecyclerView.Adapter<ToSeeListAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }

    private var toSeeList: List<ToSeeItem> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_to_see_list, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return toSeeList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val title = holderView.findViewById<TextView>(R.id.to_do_poi_title)
        val description = holderView.findViewById<TextView>(R.id.to_do_poi_description)
        title.text = toSeeList[position].poi.name
        description.text = toSeeList[position].poi.snippet
        val image = holderView.findViewById<ImageView>(R.id.to_do_image)
        if(toSeeList[position].poi.photoUrl == null || toSeeList[position].poi.photoUrl == "")
            image.visibility = View.GONE
        else
            Glide
                .with(holderView.context)
                .load(toSeeList[position].poi.photoUrl)
                .into(image)
        val seePoi = holderView.findViewById<TextView>(R.id.to_do_see_poi)
        seePoi.setOnClickListener {
            val intent = Intent(holderView.context, PoiActivity::class.java)
            intent.putExtra(PoiFragment.EXTRA_POI, toSeeList[position].poi)
            intent.putExtra(PoiFragment.EXTRA_TRAVEL_ID, travelId)
            holderView.context.startActivity(intent)
        }
        val check = holderView.findViewById<CheckBox>(R.id.to_see_item_checbox)
        check.isChecked = toSeeList[position].checked
        check.setOnCheckedChangeListener { _, t ->
            toSeeList[position].checked = t
            onChecked(toSeeList[position])
        }
    }

    fun updateCheckbox(checkedId: String, checked: Boolean){
        val itemPosition = toSeeList.indexOfFirst {it.id ==  checkedId}
        if(itemPosition != -1){
            toSeeList[itemPosition].checked = checked
            notifyItemChanged(itemPosition)
        }
    }

    public fun setData(data: List<ToSeeItem>) {
        toSeeList = data
        notifyDataSetChanged()
    }
}