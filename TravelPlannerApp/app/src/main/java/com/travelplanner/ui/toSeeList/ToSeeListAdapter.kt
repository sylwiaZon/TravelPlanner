package com.travelplanner.ui.toSeeList

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.models.ToSeeItem

class ToSeeListAdapter() : RecyclerView.Adapter<ToSeeListAdapter.ViewHolder>() {
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
        val transportName = holderView.findViewById<TextView>(R.id.item_transport_name)

    }

    public fun setData(data: List<ToSeeItem>) {
        toSeeList = data
        notifyDataSetChanged()
    }
}