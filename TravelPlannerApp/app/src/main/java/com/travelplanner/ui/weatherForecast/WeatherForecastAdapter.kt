package com.travelplanner.ui.weatherForecast

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.Tour
import com.travelplanner.models.WeatherForecast
import com.travelplanner.ui.weatherForecast.hour.WeatherForecastHourAdapter
import java.time.LocalDate
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class WeatherForecastAdapter() : RecyclerView.Adapter<WeatherForecastAdapter.ViewHolder>() {
    class ViewHolder(itemView: View, var isOpen: Boolean) : RecyclerView.ViewHolder(itemView) {
    }
    private var datesList:  List<LocalDate> = emptyList()
    private var weatherMap:  Map<LocalDate, List<WeatherForecast>> = emptyMap()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_day_weather_forecast, parent, false)
        return ViewHolder(itemView, false)
    }

    override fun getItemCount(): Int {
        return datesList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val formatter = DateTimeFormatter.ofLocalizedDate(FormatStyle.LONG)
        val recycler = holderView.findViewById<RecyclerView>(R.id.day_weather_forecast_recycler)
        val adapter = WeatherForecastHourAdapter()
        weatherMap[datesList[position]]?.let {
            adapter.setData(it)
        }
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(holderView.context)
        val downArrow = holderView.findViewById<ImageView>(R.id.weather_arrow_down)
        val upArrow = holderView.findViewById<ImageView>(R.id.weather_arrow_up)
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
        val date =  datesList[position].format(formatter)
        val holderDate = holderView.findViewById<TextView>(R.id.weather_date)
        holderDate.text = date
    }

    public fun setData(data: List<WeatherForecast>) {
        weatherMap = data.groupBy {
            it.date.toLocalDate()
        }
        datesList = weatherMap.keys.sortedBy { it }
        notifyDataSetChanged()
    }
}