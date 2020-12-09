package com.travelplanner.ui.toDoList

import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.ToDoItem
import com.travelplanner.models.ToSeeItem
import com.travelplanner.ui.poi.PoiActivity
import com.travelplanner.ui.poi.PoiFragment

class ToDoListAdapter(val travelId: String?, val onChecked: (poiId: ToDoItem) -> Unit) : RecyclerView.Adapter<ToDoListAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }

    private var toDoList: List<ToDoItem> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_to_do_list, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return toDoList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val listItem = holderView.findViewById<CheckBox>(R.id.list_item)
        listItem.text = toDoList[position].name
        listItem.isChecked = toDoList[position].checked
        listItem.setOnCheckedChangeListener { _, t ->
            toDoList[position].checked = t
            onChecked(toDoList[position])
        }
    }

    fun updateCheckbox(checkedId: String, checked: Boolean){
        val itemPosition = toDoList.indexOfFirst {it.id ==  checkedId}
        if(itemPosition != -1){
            toDoList[itemPosition].checked = checked
            notifyItemChanged(itemPosition)
        }
    }

    public fun setData(data: List<ToDoItem>) {
        toDoList = data
        notifyDataSetChanged()
    }
}